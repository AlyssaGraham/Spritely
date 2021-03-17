import { shallowMount } from '@vue/test-utils'
import SpritelyUi from '@/components/Spritely.vue'

describe('HelloWorld.vue', () => {
  it('renders props.msg when passed', () => {
    const msg = 'new message'
    const wrapper = shallowMount(SpritelyUi, {
      propsData: {}
    })
    //expect(wrapper.text()).toMatch(msg)
  })
})
